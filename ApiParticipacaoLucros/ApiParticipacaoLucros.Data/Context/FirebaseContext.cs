using FireSharp;
using FireSharp.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiParticipacaoLucros.Data.Context
{
    public class FirebaseContext
    {
        public FirebaseClient InstanciarClientFirebase()
        {
            FirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "ki0oi65EXvWCO06jDK4dDIeMpjMyf9f226WBh616",
                BasePath = "https://fir-participacaolucros-default-rtdb.firebaseio.com/"
            };
            //FirebaseConfig config = new FirebaseConfig
            //{
            //    AuthSecret = "N833KimwogrdzzLx5ybFNJI2fAKQxFydguNbWPXy",
            //    BasePath = "https://fir-plr-teste-default-rtdb.firebaseio.com/"
            //};

            FirebaseClient client = new FirebaseClient(config);
            return client;
        }

    }
}
