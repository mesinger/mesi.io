package mesi.io.clipboard.data

import mesi.io.common.clipboard.ClipboardEntry
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.stereotype.Repository

@Repository
interface ClipboardEntryRepo : JpaRepository<ClipboardEntry, Long>