package mesi.io.domain

import java.time.LocalDateTime

class JavaTimeProvider : TimeProvider {
    override fun currentTime(): LocalDateTime {
        return LocalDateTime.now()
    }
}