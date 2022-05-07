// Java Iterator interface reference:
// https://docs.oracle.com/javase/8/docs/api/java/util/Iterator.html
class PeekingIterator implements Iterator<Integer> {
    private Iterator<Integer> iter;
    private Integer firstElem;
	public PeekingIterator(Iterator<Integer> iterator) {
	    // initialize any member here.
	    iter = iterator;
        firstElem = internalNext();
	}
    
    private Integer internalNext() {
        if(iter.hasNext()) {
            return iter.next();
        } else {
            return null;
        }
    }

    // Returns the next element in the iteration without advancing the iterator.
	public Integer peek() {
        return firstElem;
	}

	// hasNext() and next() should behave the same as in the Iterator interface.
	// Override them if needed.
	@Override
	public Integer next() {
	    Integer res = firstElem;
        firstElem = internalNext();
        return res;
	}

	@Override
	public boolean hasNext() {
	    return firstElem != null;
	}
}