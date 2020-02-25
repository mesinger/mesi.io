package mesi.io.data

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.common.clipboard.ClipboardEntry
import org.slf4j.LoggerFactory
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.boot.web.client.RestTemplateBuilder
import org.springframework.context.annotation.Bean
import org.springframework.stereotype.Component
import org.springframework.web.client.RestClientException
import org.springframework.web.client.RestTemplate


@Component
class DefaultClipboardServiceApi : ClipboardServiceApi {

    @Autowired
    private lateinit var restTemplate: RestTemplate

    private val logger = LoggerFactory.getLogger(DefaultClipboardServiceApi::class.java)

    override fun getAll(): List<ClipboardEntry> {
        return try {
            restTemplate
                    .getForEntity("http://mesi-io-clipboard-service:8080/clipboard", Array<ClipboardEntry>::class.java)
                    .body?.toList() ?: listOf()
        } catch (ex : RestClientException) {
            logger.error("Clipboard API is unreachable: ${ex.message}")
            listOf()
        }
    }

    override fun add(content: ClipboardContent) {
        restTemplate.postForLocation("http://mesi-io-clipboard-service:8080/clipboard", content)
    }

    @Bean
    fun restTemplate(builder : RestTemplateBuilder) : RestTemplate {
        return builder.build()
    }
}