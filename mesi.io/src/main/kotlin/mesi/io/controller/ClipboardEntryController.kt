package mesi.io.controller

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.domain.ClipboardEntryService
import mesi.io.common.clipboard.ClipboardEntry
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.web.bind.annotation.*

@RestController
@RequestMapping("data/clipboard")
class ClipboardEntryController {

    @Autowired
    private lateinit var clipboardEntryService: ClipboardEntryService

    @RequestMapping(
            path = [""],
            method = [RequestMethod.POST],
            consumes = ["application/json"],
            produces = ["application/json"]
    )
    @CrossOrigin
    fun addClipboardEntry(@RequestBody content : ClipboardContent) : ClipboardEntry {
        return clipboardEntryService.addEntry(content)
    }

    @RequestMapping(
            path = [""],
            method = [RequestMethod.GET],
            produces = ["application/json"]
    )
    @CrossOrigin
    @ResponseBody
    fun getAllEntries() : List<ClipboardEntry> {
        return clipboardEntryService.getAll()
    }
}