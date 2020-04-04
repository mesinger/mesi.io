package mesi.io.domain

import java.time.LocalDateTime

/**
 * Returns times and dates
 */
interface TimeProvider {

    /**
     * Returns a current date and time
     */
    fun currentTime() : LocalDateTime
}