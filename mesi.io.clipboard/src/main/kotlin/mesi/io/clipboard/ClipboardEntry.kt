package mesi.io.clipboard

import java.time.LocalDateTime

data class ClipboardEntry(
        val content : String,
        val timeStamp : LocalDateTime
)