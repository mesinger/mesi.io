package mesi.io.data.clipboard

/**
 * Access to clipboard entries
 */
interface ClipboardEntryDao {

    /**
     * Gets a specific clipboard entry with given id
     */
    fun getById(id : String) : ClipboardEntry?

    /**
     * Gets all clipboard entries
     */
    fun getAll() : List<ClipboardEntry>

    /**
     * Adds a given clipboard entry
     */
    fun add(entry : ClipboardEntry)

    /**
     * Adds all clipboard entries
     */
    fun addAll(entries : List<ClipboardEntry>)
}