let _blogId='';
const tblBlog='Tbl-Blog';
runBlog();
function runBlog(){
    readBlog();
    // editBlog('758baefd-bb25-4aff-8e75-62d4fab8ff9a');
    // editBlog('0');
    //createBlog('title','author','content');

    // const id=prompt("Enter ID");
    // deleteBlog(id);

    // const id=prompt("Enter ID");
    // const title=prompt("Enter Title");
    // const author=prompt("Enter Author");
    // const content=prompt("Enter Content");
    // updateBlog(id,title,author,content);
    //localStorage.clear();
}
function readBlog(){
    $('#tbDataTable').html('');
    let lstBlog=getBlogs();
    let htmlRow='';
    for (let i = 0; i < lstBlog.length; i++) {//out by looping 
        const item = lstBlog[i];
        // console.log(item.Title);
        // console.log(item.Author);
        // console.log(item.Content);
        htmlRow+=`<tr>
        <td>
        <button type="button" class="btn btn-warning" onclick="editBlog('${item.Id}')">Edit</button>
        <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.Id}')">Delete</button>
        </td>
        <th scope="row">${i+1}</th>
        <td>${item.Title}</td>
        <td>${item.Author}</td>
        <td>${item.Content}</td>
      </tr>`;
      console.log(htmlRow);
    $('#tbDataTable').html(htmlRow);
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

    $('#Title').val(item.Title);
    $('#Author').val(item.Author);
    $('#Content').val(item.Content);
    _blogId=item.Id;
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
    readBlog();
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
    readBlog();
}
function deleteBlog(id){
    Swal.fire({
        title: "Confirm",
        text: "Are you want to delete?",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        //cancelButtonColor: "#d33",
        confirmButtonText: "Yes"
      }).then((result) => {
        if (result.isConfirmed) {
        
            let lstBlog=getBlogs();
            let lst=lstBlog.filter((x)=> x.Id===id);
            if(lst.length===0){//not equal to one
                console.log("No Data found.");
                return;
            }
            lstBlog=lstBlog.filter(x=> x.Id !== id);
            setLocalStorage(lstBlog);//mean like above
            successMessage('Deleting Successful.');
            readBlog();
        }
      });
    // let result=confirm('Are you want to delete?');
    // if(!result) return;

    // let lstBlog=getBlogs();
    // let lst=lstBlog.filter((x)=> x.Id===id);
    // if(lst.length===0){//not equal to one
    //     console.log("No Data found.");
    //     return;
    // }
    // //let item=lst[0];
    // lstBlog=lstBlog.filter(x=> x.Id !== id);//set the data that not equal id
    // //let jsonStr=JSON.stringify(lstBlogs);//change from query to json
    // //localStorage.setItem(tblBlog,jsonStr);//rewrite the values that not equal id
    // setLocalStorage(lstBlog);//mean like above
    // readBlog();
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
  
  $('#btnSave').click(function(){
    const title=$('#Title').val();
    const author=$('#Author').val();
    const content=$('#Content').val();
    //createBlog(title,author,content);
    if(_blogId===''){
        createBlog(title,author,content);
        successMessage('Saving Successful.');
    }
    else{
        updateBlog(_blogId,title,author,content);
        successMessage('Updating Successful.');
        _blogId='';
    }

    //alert("Saving Successful.");
    $('#Title').val('');
    $('#Author').val('');
    $('#Content').val('');

    $('#Title').focus();
    readBlog();
  })

   function successMessage(message){
    Swal.fire({
        title: "Success",
        text: message,
        icon: "success"
      });
  }

