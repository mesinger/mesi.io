package mesi.io.domain.clipboard

import io.mockk.*
import io.mockk.impl.annotations.InjectMockKs
import io.mockk.impl.annotations.MockK
import mesi.io.data.clipboard.ClipboardEntry
import mesi.io.data.clipboard.ClipboardEntryDao
import mesi.io.domain.common.TimeProvider
import org.junit.Before
import org.junit.Test
import org.springframework.test.util.AssertionErrors.assertEquals
import java.time.LocalDateTime

class DefaultClipboardServiceTest {

    @MockK
    private lateinit var dao : ClipboardEntryDao

    @MockK
    private lateinit var timeProvider : TimeProvider

    @InjectMockKs
    private lateinit var sut : DefaultClipboardService

    private val entry = ClipboardEntry("content", LocalDateTime.of(1999, 4, 1, 0, 0, 0))

    @Before
    fun setup() = MockKAnnotations.init(this)

    @Test
    fun testGetById() {

        // given
        every { dao.getById("1") }.returns(entry)

        // when
        val actual = sut.getById("1")

        // then
        assertEquals("Clipboard entries do not match", entry, actual)
        verify(exactly = 1) { dao.getById("1") }
    }

    @Test
    fun testGetAll() {

        // given
        val expected = listOf(entry, entry, entry)
        every { dao.getAll() }.returns(expected)

        // when
        val actual = sut.getAll()

        // then
        assertEquals("Clipboard entries do not match", expected, actual)
        verify(exactly = 1) { dao.getAll() }
    }

    @Test
    fun testAdd() {

        // given
        val addedContent = "content"
        val expectedAddedTimeStamp = LocalDateTime.of(2000, 1, 1, 0, 0, 0)
        val expectedAddedEntry = ClipboardEntry(addedContent, expectedAddedTimeStamp)

        every { timeProvider.currentTime() }.returns(expectedAddedTimeStamp)
        every { dao.add(any()) } just Runs

        // when
        sut.add(addedContent)

        // then
        verify(exactly = 1) { dao.add(expectedAddedEntry) }
    }

    @Test
    fun testAddEmptyContent() {
        // when
        sut.add("")

        // then
        verify(exactly = 0) { dao.add(any()) }
    }
}