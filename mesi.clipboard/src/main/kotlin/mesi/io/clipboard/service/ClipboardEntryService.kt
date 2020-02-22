package mesi.io.clipboard.service

import mesi.io.clipboard.data.ClipboardEntry
import mesi.io.clipboard.service.ClipboardContent

interface ClipboardEntryService {
    fun addEntry(content : ClipboardContent) : ClipboardEntry
    fun getAll() : List<ClipboardEntry>
}