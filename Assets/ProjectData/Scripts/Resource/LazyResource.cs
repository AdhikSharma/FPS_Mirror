using UnityEngine;

namespace Adhik.Resource 
{
    //ref link : https://gist.github.com/mattak/fac6b596406d557fd3c3a5497f2646f7
    public class LazyResource<T> where T : UnityEngine.Object
    {
        public T _value;
        public T Value
        {
            get
            {
                if (_value == null)
                {
                    lock (this)
                    {
                        if (_value == null)
                        {
                            _value = Resources.Load<T>(path);
                        }
                    }
                }

                return _value;
            }
        }

        private string path;

        public LazyResource(string path)
        {
            this.path = path;
        }
    }
}

