package mesi.io.domain

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry

interface ClipboardService {
    fun getAll() : List<ClipboardEntry>
    fun add(content : ClipboardContent)
}