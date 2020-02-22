package mesi.io.clipboard.data

import org.springframework.data.jpa.repository.JpaRepository
import java.time.LocalDateTime
import javax.persistence.*

@Entity
@Table(name = "clipboardentries")
data class ClipboardEntry (

        @Id
        @GeneratedValue(strategy = GenerationType.IDENTITY)
        val id : Long,

        @Column(nullable = false, length = 512)
        val content : String,

        @Column(nullable = false)
        val timeStamp : LocalDateTime
)

interface ClipboardEntryRepo : JpaRepository<ClipboardEntry, Long>
