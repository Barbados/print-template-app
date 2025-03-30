namespace print_template_app.Interfaces;

public interface IPrintTemplateService
{
    Task Prepare();

    Task Load(string data);

    Task Print();
}