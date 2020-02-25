package mesi.io.data

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry

interface ClipboardServiceApi {
    fun getAll() : List<ClipboardEntry>
    fun add(content : ClipboardContent)
}