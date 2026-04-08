using DragonVu.Data;
using DragonVu.Models;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static async Task SeedGeneralChapter(AppDbContext context, string rootPath)
    {

        // جلب كل المواد
        var subjects = await context.subjects.ToListAsync();

        foreach (var subject in subjects)
        {
            // التأكد من وجود فصل "General" لكل مادة
            var generalChapter = await context.chapters
                .FirstOrDefaultAsync(c => c.Name == "General" && c.SubjectId == subject.Id);

            if (generalChapter == null)
            {
                generalChapter = new Chapter
                {
                    Name = "General",
                    SubjectId = subject.Id
                };
                context.chapters.Add(generalChapter);
                await context.SaveChangesAsync();
            }

            // مجلد المادة + General
            string subjectFolder = Path.Combine(rootPath, subject.Id.ToString());
            string generalFolder = Path.Combine(subjectFolder, "Questions", "General");

            if (!Directory.Exists(generalFolder))
            {
                Directory.CreateDirectory(generalFolder);
            }

            // جلب جميع الأسئلة الخاصة بالمادة
            var questions = await context.questions
                .Where(q => q.SubjectId == subject.Id)
                .ToListAsync();

            foreach (var question in questions)
            {
                // إنشاء نسخة من السؤال للفصل العام
                var generalQuestion = new Question
                {
                    Text = question.Text,
                    ImageUrl = question.ImageUrl,
                    SubjectId = question.SubjectId,
                    ChapterId = generalChapter.Id,
                    AnswerD = question.AnswerD,
                    AnswerA = question.AnswerA,
                    AnswerB = question.AnswerB,
                    AnswerC = question.AnswerC,
                    ApprovedAt = question.ApprovedAt,
                    ApprovedById = question.ApprovedById,
                    CorrectAnswer = question.CorrectAnswer,
                    CreatedById = question.CreatedById,
                    CreatedAt = question.CreatedAt,
                    Status = question.Status,
                    Hint = question.Hint,

                };

                context.questions.Add(generalQuestion);

                // نسخ الملف إن وجد
                if (!string.IsNullOrEmpty(question.ImageUrl))
                {
                    string sourceFile = Path.Combine(subjectFolder, question.ImageUrl);
                    string destFile = Path.Combine(generalFolder, question.ImageUrl);

                    if (File.Exists(sourceFile) && !File.Exists(destFile))
                    {
                        File.Copy(sourceFile, destFile);
                    }
                }
            }

            await context.SaveChangesAsync();
        }
    }
}