package mesi.io.data.clipboard.mongo

import mesi.io.data.clipboard.ClipboardEntry
import mesi.io.data.clipboard.ClipboardEntryDao
import mesi.io.data.clipboard.MappingConfiguration.map
import mesi.io.data.clipboard.MappingConfiguration.mapToMongoDb
import org.springframework.beans.factory.annotation.Autowired

class MongoClipboardEntryDao : ClipboardEntryDao {

    @Autowired
    private lateinit var repo : MongoClipboardEntryRepository

    override fun getById(id: String): ClipboardEntry? {
        val optional = repo.findById(id)
        return if(optional.isPresent) optional.get().map() else null
    }

    override fun getAll(): List<ClipboardEntry> {
        return repo.findAll().map { it.map() }
    }

    override fun add(entry: ClipboardEntry) {
        repo.save(entry.mapToMongoDb())
    }

    override fun addAll(entries: List<ClipboardEntry>) {
        repo.saveAll(entries.map { it.mapToMongoDb() })
    }
}