package mesi.io.domain.clipboard

import mesi.io.data.clipboard.ClipboardEntry

/**
 * Access to clipboard entries
 */
interface ClipboardService {

    /**
     * Returns a clipboard entry with given id
     */
    fun getById(id : String) : ClipboardEntry?

    /**
     * Returns all clipboard entries
     */
    fun getAll() : List<ClipboardEntry>

    /**
     * Adds a new clipboard entry with given content
     */
    fun add(content : String)
}