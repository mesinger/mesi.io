package mesi.io.common.clipboard

import java.time.LocalDateTime
import javax.persistence.*

@Entity
data class ClipboardEntry (

        @Id
        @GeneratedValue(strategy = GenerationType.IDENTITY)
        val id : Long,

        @Column(nullable = false, length = 512)
        val content : String,

        @Column(nullable = false)
        val timeStamp : LocalDateTime
)
