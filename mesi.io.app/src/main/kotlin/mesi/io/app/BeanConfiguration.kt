package mesi.io.app

import mesi.io.clipboard.ClipboardEntryDao
import mesi.io.clipboard.MongoClipboardEntryDao
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
}