package mesi.io.app

//import org.springframework.beans.factory.annotation.Autowired
//import org.springframework.context.annotation.Bean
//import org.springframework.http.HttpMethod
//import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder
//import org.springframework.security.config.annotation.web.builders.HttpSecurity
//import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity
//import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter
//import org.springframework.security.core.userdetails.UserDetailsService
//import org.springframework.security.crypto.password.NoOpPasswordEncoder
//import org.springframework.security.crypto.password.PasswordEncoder
//
//@EnableWebSecurity
//class CustomWebSecurityConfigurerAdapter : WebSecurityConfigurerAdapter() {
//
//    @Autowired
//    private lateinit var userDetailsService : UserDetailsService
//
//    override fun configure(auth: AuthenticationManagerBuilder) {
//        auth.userDetailsService(userDetailsService)
//    }
//
//    override fun configure(http: HttpSecurity) {
//        http.httpBasic()
//                .and().authorizeRequests()
//                .antMatchers(HttpMethod.GET,"/api/clipboard/**").hasRole("r_user")
//                .antMatchers("/api/clipboard/**").hasRole("rw_user")
//                .and()
//                .csrf().disable()
//                .formLogin().disable()
//    }
//
//    @Bean
//    fun passwordEncoder(): PasswordEncoder = NoOpPasswordEncoder.getInstance()
//}
