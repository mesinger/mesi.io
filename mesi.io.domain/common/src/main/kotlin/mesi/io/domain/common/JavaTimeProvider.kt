package mesi.io.domain.common

import java.time.LocalDateTime

class JavaTimeProvider : TimeProvider {
    override fun currentTime(): LocalDateTime {
        return LocalDateTime.now()
    }
}