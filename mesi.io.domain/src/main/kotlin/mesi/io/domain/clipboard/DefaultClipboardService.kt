package mesi.io.domain.clipboard

import mesi.io.clipboard.ClipboardEntry
import mesi.io.clipboard.ClipboardEntryDao
import mesi.io.clipboard.MongoClipboardEntryRepository
import org.springframework.beans.factory.annotation.Autowired
import java.time.LocalDateTime

class DefaultClipboardService : ClipboardService {

    @Autowired
    private lateinit var dao : ClipboardEntryDao

    override fun getById(id: String): ClipboardEntry? {
        return dao.getById(id)
    }

    override fun getAll(): List<ClipboardEntry> {
        return dao.getAll().sortedByDescending { it.timeStamp }
    }

    override fun add(content: String) {
        dao.add(ClipboardEntry(content, LocalDateTime.now()))
    }
}