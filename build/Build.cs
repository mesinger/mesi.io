using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Aws);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    AbsolutePath AwsPublishDirectory => RootDirectory / "publish";
    AbsolutePath AwsPublishedArchive => RootDirectory / "publish.zip";
    AbsolutePath DockerDirectory => RootDirectory / "docker";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target Aws => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            EnsureCleanDirectory(AwsPublishDirectory);
            DeleteDirectory(AwsPublishDirectory);
            DeleteFile(AwsPublishedArchive);

            DotNetPublish(s => s
                .SetProject(SourceDirectory / "Mesi.Io.Api.User")
                .SetOutput(AwsPublishDirectory / "user-api/app"));
            CopyFile(DockerDirectory / "Dockerfile-User", AwsPublishDirectory / "user-api" / "Dockerfile");
            
            DotNetPublish(s => s
                .SetProject(SourceDirectory / "Mesi.Io.Api.Clipboard")
                .SetOutput(AwsPublishDirectory / "clipboard-api/app"));
            CopyFile(DockerDirectory / "Dockerfile-Clipboard", AwsPublishDirectory / "clipboard-api" / "Dockerfile");
            
            CopyDirectoryRecursively(SourceDirectory / "frontend-mesi-io", AwsPublishDirectory / "frontend",
                excludeFile: fileInfo =>
                    fileInfo.DirectoryName.Contains("node_modules"));
            CopyFile(DockerDirectory / "Dockerfile-Frontend", AwsPublishDirectory / "frontend" / "Dockerfile");
            CopyFile(DockerDirectory / "default.conf", AwsPublishDirectory / "frontend" / "default.conf");

            CopyFile(DockerDirectory / "docker-compose.yml", AwsPublishDirectory / "docker-compose.yml");
            CopyFile(DockerDirectory / "start.bat", AwsPublishDirectory / "start.bat");
            CopyFile(DockerDirectory / "stop.bat", AwsPublishDirectory / "stop.bat");

            CompressionTasks.Compress(AwsPublishDirectory, AwsPublishedArchive);
            
            EnsureCleanDirectory(AwsPublishDirectory);
            DeleteDirectory(AwsPublishDirectory);
        });
}
