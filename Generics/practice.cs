// sketch a generic class Repository<T> that stores items in a private List<T>, 
// has an Add(T item) method, and a GetAll() method returning the list. 
// Then the twist question: if you wanted a FindById(int id) method inside it,
//  what problem hits you immediately, and which part of today's lesson is the fix?
class Repository<T>{
  private  List<T> items = new List<T>();
  public List<T> AddItem(T item){
    return items.Add(item);
  }
  public List<T> GetAll(){
    return items;
  }
}