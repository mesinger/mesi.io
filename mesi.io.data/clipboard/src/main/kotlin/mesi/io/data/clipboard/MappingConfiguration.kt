package mesi.io.data.clipboard

import mesi.io.data.clipboard.mongo.MongoClipboardEntry

internal object MappingConfiguration {
    fun MongoClipboardEntry.map() = ClipboardEntry(content, timeStamp)
    fun ClipboardEntry.mapToMongoDb() = MongoClipboardEntry("", content, timeStamp)
}