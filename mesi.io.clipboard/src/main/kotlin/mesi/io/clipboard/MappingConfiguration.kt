package mesi.io.clipboard

internal object MappingConfiguration {
    fun MongoClipboardEntry.map() = ClipboardEntry(content, timeStamp)
    fun ClipboardEntry.mapToMongoDb() = MongoClipboardEntry("", content, timeStamp)
}