package mesi.io.clipboard.data

import mesi.io.common.clipboard.ClipboardEntry
import org.springframework.data.jpa.repository.JpaRepository

interface ClipboardEntryRepo : JpaRepository<ClipboardEntry, Long>