package mesi.io.data.clipboard

import com.fasterxml.jackson.annotation.JsonFormat
import java.time.LocalDateTime

data class ClipboardEntry(

        val content : String,

        @JsonFormat(pattern = "yyyy-MM-dd HH:mm:ss")
        val timeStamp : LocalDateTime
)