package mesi.io.app.controller

import mesi.io.domain.clipboard.ClipboardContent
import mesi.io.domain.clipboard.ClipboardService
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.stereotype.Controller
import org.springframework.ui.Model
import org.springframework.web.bind.annotation.*

@Controller
class HomeController : BaseController() {

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
        var clipboardEntries = clipboardService.getAll().map { it.content }
        var shortenedClipboardEntries = clipboardEntries.map { if (it.length < 20) it else "${it.take(20)}..." }
        model.addAttribute("clipboardEntries", clipboardEntries)
        model.addAttribute("shortenedClipboardEntries", shortenedClipboardEntries)
        model.addAttribute("newEntryContent", ClipboardContent(""))
        return "clipboard"
    }

    @PostMapping(
            path = ["clipboard"]
    )
    private fun addToClipboard(model: Model, @ModelAttribute content : ClipboardContent) : String {
        clipboardService.add(content.raw)
        return clipboard(model)
    }
}