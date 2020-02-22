package mesi.io.clipboard.controller

import mesi.io.clipboard.service.ClipboardContent
import mesi.io.clipboard.service.ClipboardEntryService
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Controller
import org.springframework.ui.Model
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.ModelAttribute
import org.springframework.web.bind.annotation.PostMapping

@Controller
class IndexController {

    @Autowired
    private lateinit var clipboardEntryService: ClipboardEntryService

    @GetMapping(
            path = ["", "index"],
            produces = ["text/html"]
    )
    fun index(model : Model) : String {
        model.addAttribute("clipboardEntries", clipboardEntryService.getAll())
        model.addAttribute("newEntryContent", ClipboardContent(""))
        return "index"
    }

    @PostMapping(
            path = ["io"]
    )
    fun submitNewContent(model : Model, @ModelAttribute content: ClipboardContent) : String {
        clipboardEntryService.addEntry(content)
        return index(model)
    }
}