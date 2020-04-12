package mesi.io.app.controller

import mesi.io.domain.clipboard.ClipboardContent
import mesi.io.data.clipboard.ClipboardEntry
import mesi.io.domain.clipboard.ClipboardService
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.http.HttpStatus
import org.springframework.web.bind.annotation.*

@RestController
@RequestMapping("api/clipboard")
class ClipboardController {

    @Autowired
    private lateinit var service : ClipboardService

    @RequestMapping(
            method = [RequestMethod.GET],
            path = [""],
            produces = ["application/json"]
    )
    fun getAll() : List<ClipboardEntry> {
        return service.getAll()
    }

    @RequestMapping(
            method = [RequestMethod.POST],
            path = [""],
            consumes = ["application/json"]
    )
    @ResponseStatus(HttpStatus.CREATED)
    fun add(@RequestBody content : ClipboardContent) {
        service.add(content.raw)
    }
}