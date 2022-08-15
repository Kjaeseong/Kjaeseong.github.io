public interface I_Subject
{
    void AddObserver(Observer o);

    void RemoveObserver(Observer o);

    void Notify();
}