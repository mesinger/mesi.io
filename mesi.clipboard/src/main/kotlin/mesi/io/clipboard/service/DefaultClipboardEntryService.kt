package mesi.io.clipboard.service

import mesi.io.clipboard.data.ClipboardEntryRepo
import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry
import org.slf4j.LoggerFactory
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Component
import java.time.LocalDateTime

@Component
class DefaultClipboardEntryService : ClipboardEntryService {

    @Autowired
    private lateinit var clipboardEntryRepo: ClipboardEntryRepo

    private val logger = LoggerFactory.getLogger(DefaultClipboardEntryService::class.java)

    override fun addEntry(content: ClipboardContent) : ClipboardEntry {
        val currentTime = LocalDateTime.now()
        val clipboardEntry = ClipboardEntry(0, content.content, currentTime)
        logger.info("Persisting new clipboard entry $clipboardEntry")
        return clipboardEntryRepo.save(clipboardEntry)
    }

    override fun getAll(): List<ClipboardEntry> {
        return clipboardEntryRepo.findAll()
    }
}