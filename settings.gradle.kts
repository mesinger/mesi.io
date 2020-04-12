rootProject.name = "mesi.io"

include("app")
project(":app").projectDir = file("mesi.io.app")

include("domain-common")
project(":domain-common").projectDir = file("mesi.io.domain/common")

include("domain-clipboard")
project(":domain-clipboard").projectDir = file("mesi.io.domain/clipboard")

include("data-clipboard")
project(":data-clipboard").projectDir = file("mesi.io.data/clipboard")
