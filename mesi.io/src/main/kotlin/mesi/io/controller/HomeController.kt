package mesi.io.controller

import mesi.io.common.clipboard.ClipboardContent
import mesi.io.domain.ClipboardService
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Controller
import org.springframework.ui.Model
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.ModelAttribute
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RequestMethod

@Controller
class HomeController {

    private val logger = org.slf4j.LoggerFactory.getLogger(HomeController::class.java)

    @Autowired
    private lateinit var clipboardService: ClipboardService

    @GetMapping(
            path = ["", "index"],
            produces = ["text/html"]
    )
    fun index(model : Model) : String {
        return "index"
    }

    @GetMapping(
            path = ["clipboard"],
            produces = ["text/html"]
    )
    fun clipboard(model: Model) : String {
        var clipboardEntries = clipboardService.getAll()
        model.addAttribute("clipboardEntries", clipboardEntries)
        model.addAttribute("newEntryContent", ClipboardContent(""))
        return "clipboard"
    }

    @RequestMapping(
            path = ["/clipboard"],
            method = [RequestMethod.POST]
    )
    fun addToClipboard(model: Model, @ModelAttribute content : ClipboardContent) : String {
        clipboardService.add(content)
        return clipboard(model)
    }
}