package mesi.io.clipboard.service

import mesi.io.clipboard.data.ClipboardEntry
import mesi.io.clipboard.data.ClipboardEntryRepo
import mesi.io.clipboard.service.ClipboardContent
import mesi.io.clipboard.service.ClipboardEntryService
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Component
import java.time.LocalDateTime

@Component
class DefaultClipboardEntryService : ClipboardEntryService {

    @Autowired
    private lateinit var clipboardEntryRepo: ClipboardEntryRepo

    override fun addEntry(content: ClipboardContent) : ClipboardEntry {
        val currentTime = LocalDateTime.now()
        val clipboardEntry = ClipboardEntry(0, content.content, currentTime)
        return clipboardEntryRepo.save(clipboardEntry)
    }

    override fun getAll(): List<ClipboardEntry> {
        return clipboardEntryRepo.findAll()
    }
}