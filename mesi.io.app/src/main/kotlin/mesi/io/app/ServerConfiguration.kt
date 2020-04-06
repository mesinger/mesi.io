package mesi.io.app

//import org.apache.catalina.Context
//import org.apache.catalina.connector.Connector
//import org.apache.tomcat.util.descriptor.web.SecurityCollection
//import org.apache.tomcat.util.descriptor.web.SecurityConstraint
//import org.springframework.boot.web.embedded.tomcat.TomcatServletWebServerFactory
//import org.springframework.boot.web.servlet.server.ServletWebServerFactory
//import org.springframework.context.annotation.Bean
//import org.springframework.context.annotation.Configuration
//
//
//@Configuration
//class ServerConfiguration {
//
//    @Bean
//    fun servletWebServerFactory() : ServletWebServerFactory {
//        val tomcat: TomcatServletWebServerFactory = object : TomcatServletWebServerFactory() {
//            override fun postProcessContext(context: Context) {
//                val securityConstraint = SecurityConstraint()
//                securityConstraint.userConstraint = "CONFIDENTIAL"
//                val collection = SecurityCollection()
//                collection.addPattern("/*")
//                securityConstraint.addCollection(collection)
//                context.addConstraint(securityConstraint)
//            }
//        }
//        tomcat.addAdditionalTomcatConnectors(getHttpConnector())
//        return tomcat
//    }
//
//    private fun getHttpConnector() : Connector {
//        val connector = Connector(TomcatServletWebServerFactory.DEFAULT_PROTOCOL)
//        connector.scheme = "http"
//        connector.port = 8080
//        connector.secure = false
//        connector.redirectPort = 443
//        return connector
//    }
//}