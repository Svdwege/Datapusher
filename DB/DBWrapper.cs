namespace addDataToDB.DB{

    class DBWrapper
    {
        public S3DigitalTwinContext db {get; set;}
        public DBWrapper(S3DigitalTwinContext? context){
            if(context != null){
                db = context;
            }
            else {db = new S3DigitalTwinContext();}
        }
        
        public void LoadData(List<TestPattern> data){
            foreach(TestPattern tp in data){
                db.TestPatterns.Add(tp);
            }
            db.SaveChanges();
        }


        public void Reset(){
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.SaveChanges();
        }
        
    }
}
