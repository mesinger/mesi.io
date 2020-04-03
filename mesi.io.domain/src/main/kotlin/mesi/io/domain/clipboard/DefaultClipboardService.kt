package mesi.io.domain.clipboard

import mesi.io.clipboard.ClipboardEntry
import mesi.io.clipboard.ClipboardEntryDao
import mesi.io.clipboard.MongoClipboardEntryRepository
import org.slf4j.LoggerFactory
import org.springframework.beans.factory.annotation.Autowired
import java.time.LocalDateTime

class DefaultClipboardService : ClipboardService {

    private val logger = LoggerFactory.getLogger(DefaultClipboardService::class.java)

    @Autowired
    private lateinit var dao : ClipboardEntryDao

    override fun getById(id: String): ClipboardEntry? {
        return dao.getById(id)
    }

    override fun getAll(): List<ClipboardEntry> {
        return dao.getAll().sortedByDescending { it.timeStamp }
    }

    override fun add(content: String) {

        if(content == "") {
            logger.warn("Attempting to add a new clipboard entry with empty content")
            return
        }

        val newEntry = ClipboardEntry(content, LocalDateTime.now())

        logger.info("Adding new clipboard entry $newEntry")

        dao.add(newEntry)
    }
}