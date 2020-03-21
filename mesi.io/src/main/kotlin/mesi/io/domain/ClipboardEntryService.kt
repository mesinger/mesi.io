package mesi.io.domain

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry

interface ClipboardEntryService {
    fun addEntry(content : ClipboardContent) : ClipboardEntry
    fun getAll() : List<ClipboardEntry>
}