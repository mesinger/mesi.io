package mesi.io.clipboard

import org.springframework.data.annotation.Id
import org.springframework.data.mongodb.core.mapping.Document
import org.springframework.data.mongodb.core.mapping.Field
import org.springframework.data.mongodb.repository.MongoRepository
import org.springframework.stereotype.Component
import org.springframework.stereotype.Repository
import java.time.LocalDateTime

@Document(collection = "clipboardentries")
data class MongoClipboardEntry (
        @Id
        val id : String,

        val content : String,

        @Field("time_stamp")
        val timeStamp : LocalDateTime
)

@Repository
interface MongoClipboardEntryRepository : MongoRepository<MongoClipboardEntry, String>
