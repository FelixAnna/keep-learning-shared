/**
 * In java, we can use static nested class to make the state private in memento and still visible to outer class functions, which is safer than expose them * 
 */
public class Originator {
    private String state;

    public void set(String state) {
        this.state = state;
    }

    public String getState() {
        return state;
    }

    public Memento takeSnapshot() {
        return new Memento(this.state);
    }

    public void restore(Memento memento) {
        this.state = memento != null ? memento.getSavedState() : null;
    }

    public static class Memento {
        private final String state;

        private Memento(String stateToSave) {
            state = stateToSave;
        }

        private String getSavedState() {
            return state;
        }
    }
}

public class CareTaker {
    private final Originator originator;
    private final Stack<Originator.Memento> history;

    public CareTaker(Originator originator){
        this.originator = originator;
        history = new Stack<>();
    }

    public void append(String text){
        history.add(originator.takeSnapshot());
        originator.set(originator.getState() + text);

        System.out.println(originator.getState());
    }

    public  void undo(){
        if(!history.isEmpty()) {
            originator.restore(history.pop());
            System.out.println(originator.getState());
        }
    }
}

Originator originator = new Originator();
originator.set("start");
CareTaker careTaker = new CareTaker(originator);

careTaker.append(" at");
careTaker.append(" shenzhen");
careTaker.append(" nanshan");

careTaker.undo();
careTaker.undo();
careTaker.undo();