package mesi.io.data.clipboard

import java.time.LocalDateTime

data class ClipboardEntry(
        val content : String,
        val timeStamp : LocalDateTime
)