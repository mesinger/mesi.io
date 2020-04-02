package mesi.io.app

import com.fasterxml.jackson.core.JsonParseException
import com.fasterxml.jackson.databind.exc.MismatchedInputException
import com.fasterxml.jackson.module.kotlin.MissingKotlinParameterException
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.ControllerAdvice
import org.springframework.web.bind.annotation.ExceptionHandler

@ControllerAdvice
private class JacksonExceptionController {

    @ExceptionHandler(JsonParseException::class, MismatchedInputException::class, MissingKotlinParameterException::class)
    fun onParseException() : ResponseEntity<String> {
        return ResponseEntity.badRequest().body("Invalid request body")
    }
}