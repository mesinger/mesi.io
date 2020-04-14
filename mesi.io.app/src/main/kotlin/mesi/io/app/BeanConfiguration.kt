package mesi.io.app

import mesi.io.data.clipboard.ClipboardEntryDao
import mesi.io.data.clipboard.mongo.MongoClipboardEntryDao
import mesi.io.domain.common.JavaTimeProvider
import mesi.io.domain.common.TimeProvider
import mesi.io.domain.clipboard.ClipboardService
import mesi.io.domain.clipboard.DefaultClipboardService
import org.springframework.context.annotation.Bean
import org.springframework.context.annotation.Configuration

@Configuration
internal class BeanConfiguration {

    @Bean
    fun clipboardService() : ClipboardService = DefaultClipboardService()

    @Bean
    fun clipboardEntryDao() : ClipboardEntryDao = MongoClipboardEntryDao()

    @Bean
    fun timeProvider() : TimeProvider = JavaTimeProvider()

//    @Bean
//    fun userDetailsService() : UserDetailsService = MongoUserDetailsService()
}