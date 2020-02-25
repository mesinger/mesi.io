package mesi.io.domain

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry
import mesi.io.data.ClipboardServiceApi
import org.slf4j.LoggerFactory
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Component

@Component
class DefaultClipboardService : ClipboardService {

    @Autowired
    private lateinit var clipboardServiceApi: ClipboardServiceApi

    private val logger = LoggerFactory.getLogger(DefaultClipboardService::class.java)

    override fun getAll(): List<ClipboardEntry> {
        return clipboardServiceApi.getAll()
    }

    override fun add(content: ClipboardContent) {
        logger.info("Posting new clipboard content to API, $content")
        clipboardServiceApi.add(content)
    }
}