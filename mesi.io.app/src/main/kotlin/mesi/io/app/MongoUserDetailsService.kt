package mesi.io.app

//import org.slf4j.LoggerFactory
//import org.springframework.beans.factory.annotation.Autowired
//import org.springframework.data.annotation.Id
//import org.springframework.data.mongodb.core.mapping.Document
//import org.springframework.data.mongodb.repository.MongoRepository
//import org.springframework.security.core.GrantedAuthority
//import org.springframework.security.core.authority.SimpleGrantedAuthority
//import org.springframework.security.core.userdetails.UserDetails
//import org.springframework.security.core.userdetails.UserDetailsService
//import org.springframework.security.core.userdetails.UsernameNotFoundException
//import java.util.*
//
//class MongoUserDetailsService : UserDetailsService {
//
//    @Autowired
//    private lateinit var userRepository: MongoUserRepository
//
//    private val logger = LoggerFactory.getLogger(MongoUserDetailsService::class.java)
//
//    override fun loadUserByUsername(username: String): UserDetails {
//        val user = userRepository.findByName(username)
//
//        user.orElseThrow {
//            logger.info("User $username not found")
//            throw UsernameNotFoundException("User $username not found")
//        }
//
//        return user.get().toUserDetails()
//    }
//}
//
//private interface MongoUserRepository : MongoRepository<MongoUser, String> {
//    fun findByName(name : String) : Optional<MongoUser>
//}
//
//@Document("users")
//private data class MongoUser (
//
//    @Id
//    val id : String,
//
//    val name : String,
//
//    val password : String,
//
//    val roles : List<String>
//)
//
//private fun MongoUser.toUserDetails() : UserDetails {
//    return DefaultUserDetails(
//            userName = name,
//            password = password,
//            authorities = roles.map { SimpleGrantedAuthority("ROLE_$it") }.toMutableList(),
//            isEnabled = true,
//            isCredentialsNonExpired = true,
//            isAccountNonExpired = true,
//            isAccountNonLocked = true
//    )
//}
//
//private class DefaultUserDetails(
//        private val userName : String,
//        private val password : String,
//        private val authorities : MutableList<GrantedAuthority>,
//        private val isEnabled : Boolean,
//        private val isCredentialsNonExpired : Boolean,
//        private val isAccountNonExpired : Boolean,
//        private val isAccountNonLocked : Boolean
//) : UserDetails {
//
//    override fun getAuthorities(): MutableCollection<out GrantedAuthority> {
//        return authorities
//    }
//
//    override fun isEnabled(): Boolean {
//        return isEnabled
//    }
//
//    override fun getUsername(): String {
//        return userName
//    }
//
//    override fun isCredentialsNonExpired(): Boolean {
//        return isCredentialsNonExpired
//    }
//
//    override fun getPassword(): String {
//        return password
//    }
//
//    override fun isAccountNonExpired(): Boolean {
//        return isAccountNonExpired
//    }
//
//    override fun isAccountNonLocked(): Boolean {
//        return isAccountNonLocked
//    }
//}
