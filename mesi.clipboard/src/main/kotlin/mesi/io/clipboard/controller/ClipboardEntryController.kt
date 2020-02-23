package mesi.io.clipboard.controller

import mesi.io.clipboard.service.ClipboardContent
import mesi.io.clipboard.service.ClipboardEntryService
import mesi.io.common.clipboard.ClipboardEntry
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.web.bind.annotation.*

@RestController
@RequestMapping("clipboard")
class ClipboardEntryController {

    @Autowired
    private lateinit var clipboardEntryService: ClipboardEntryService

    @RequestMapping(
            path = [""],
            method = [RequestMethod.POST],
            consumes = ["application/json"],
            produces = ["application/json"]
    )
    fun addClipboardEntry(@RequestBody content : ClipboardContent) : ClipboardEntry {
        return clipboardEntryService.addEntry(content)
    }

    @RequestMapping(
            path = [""],
            method = [RequestMethod.GET],
            produces = ["application/json"]
    )
    @ResponseBody
    fun getAllEntries() : List<ClipboardEntry> {
        return clipboardEntryService.getAll()
    }
}