public abstract class Observer<T> : ObserverBase where T : Subject
{
    protected T mySubject = default;

    public void SetUp()
    {
        mySubject = FindObjectOfType<T>();
        mySubject.AttachObserver(this);
    }
}
