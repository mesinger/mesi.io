package mesi.io.clipboard.service

import mesi.io.common.clipboard.ClipboardEntry

interface ClipboardEntryService {
    fun addEntry(content : ClipboardContent) : ClipboardEntry
    fun getAll() : List<ClipboardEntry>
}