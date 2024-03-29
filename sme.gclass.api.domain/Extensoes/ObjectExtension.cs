﻿namespace SME.GoogleClassroom.Dominio
{
    public static class ObjectExtension
    {
        public static bool EhNulo(this object objeto)
        {
            return objeto is null;
        }

        public static bool NaoEhNulo(this object objeto)
        {
            return !(objeto is null);
        }
        public static bool MaiorQueZero(this int numero) => numero > 0;
        public static bool MaiorQueZero(this long numero) => numero > 0;
        
        public static bool IgualZero(this object numero) => numero is 0;
        
    }
}