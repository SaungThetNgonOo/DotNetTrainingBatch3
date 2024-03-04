const tblBlog='Tbl-Blog';
runBlog();
function runBlog(){
    //readBlog();
    // editBlog('758baefd-bb25-4aff-8e75-62d4fab8ff9a');
    // editBlog('0');
    createBlog('title','author','content');

    //const id=prompt("Enter ID");
    //deleteBlog(id);

//     const id=prompt("Enter ID");
//     const title=prompt("Enter Title");
//     const author=prompt("Enter Author");
//     const content=prompt("Enter Content");
//     updateBlog(id,title,author,content);
}
function readBlog(){
    let lstBlog=getBlogs();
    for (let i = 0; i < lstBlog.length; i++) {//out by looping 
        const item = lstBlog[i];
        console.log(item.Title);
        console.log(item.Author);
        console.log(item.Content);
    }
}
function editBlog(id){
    let lstBlog=getBlogs();
    let lst=lstBlog.filter((x)=> x.Id===id);//filter out by arr of first index zero
    //console.log(lst);
    if(lst.length===0){//not equal to one
        console.log("No Data found.");
        return;
    }
    let item=lst[0];
    console.log(item);
}
function createBlog(title,author,content){
    let lstBlog=getBlogs();//readed value assigned to lstBlog
    const blog={
        Id: uuidv4(),
        Title:title,
        Author:author,
        Content:content
    }
    lstBlog.push(blog);//add query by lstBlog
    //let jsonStr=JSON.stringify(lstBlogs);//change from query to json
    //localStorage.setItem(tblBlog,jsonStr)//set json in localStorage by db
    setLocalStorage(lstBlog);
}
function updateBlog(id,title,author,content){
    let lstBlog=getBlogs();
    let lst=lstBlog.filter((x)=> x.Id===id);
    if(lst.length===0){//not equal to one
        console.log("No Data found.");
        return;
    }
    let index=lstBlog.findIndex((x) =>x.Id===id );
    lstBlog[index]={
        Id:id,
        Title:title,
        Author:author,
        Content:content
    }
    setLocalStorage(lstBlog);
}
function deleteBlog(id){
    let lstBlog=getBlogs();
    let lst=lstBlog.filter((x)=> x.Id===id);
    if(lst.length===0){//not equal to one
        console.log("No Data found.");
        return;
    }
    //let item=lst[0];
    lstBlog=lstBlog.filter(x=> x.Id !== id);//set the data that not equal id
    //let jsonStr=JSON.stringify(lstBlogs);//change from query to json
    //localStorage.setItem(tblBlog,jsonStr);//rewrite the values that not equal id
    setLocalStorage(lstBlog);//mean like above
}
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
  }

  function getBlogs(){
    let lstBlogs=[];
    let blogStr=localStorage.getItem(tblBlog);
    if(blogStr!==null){
        lstBlogs=JSON.parse(blogStr);
    }
    return lstBlogs;
  }

  function setLocalStorage(blogs){
    let jsonStr=JSON.stringify(blogs);
    localStorage.setItem(tblBlog,jsonStr);
  }
  