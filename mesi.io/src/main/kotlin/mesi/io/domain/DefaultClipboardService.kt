package mesi.io.domain

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry
import mesi.io.controller.ClipboardEntryController
import mesi.io.data.ClipboardEntryRepo
import org.slf4j.LoggerFactory
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Component

@Component
class DefaultClipboardService : ClipboardService {

    @Autowired
    private lateinit var clipboardEntryController: ClipboardEntryController

    private val logger = LoggerFactory.getLogger(DefaultClipboardService::class.java)

    override fun getAll(): List<ClipboardEntry> {
        return clipboardEntryController.getAllEntries()
    }

    override fun add(content: ClipboardContent) {
        clipboardEntryController.addClipboardEntry(content)
    }
}