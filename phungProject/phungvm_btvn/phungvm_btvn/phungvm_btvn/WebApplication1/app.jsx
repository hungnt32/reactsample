var CommentBox = React.createClass({
    loadCommentsFromServer: function(){
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function(){
            var data = JSON.parse(xhr.responseText);
            this.setState({data : data});
        }.bind(this);
        xhr.send();
    },
    handleCommentSubmit: function(comment){
        var comments = this.state.data;
        comment.Id = Date.now();
        //var newComments = comments.concat([comment]);
        //this.setState({data: newComments});

        // var data = new FormData();
        // data.append('Author', comment.author);
        // data.append('Description', comment.description);
        var data = JSON.stringify(comment);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.setRequestHeader('Content-Type','application/json; charset=utf-8');
        xhr.onload = function(){
            this.loadCommentsFromServer();
        }.bind(this);
        xhr.send(data);
    },
    getInitialState: function(){
        return {data: []};
    },
    componentDidMount: function(){
        this.loadCommentsFromServer();
        window.setInterval(this.loadCommentsFromServer, this.props.pollInterval);
    },
    render: function(){
        return (
          <div className="commentBox">
            <h1>Comments</h1>
            <CommentList data={this.state.data} />
            <CommentForm onCommentSubmit={this.handleCommentSubmit} />
          </div>
      );
    }
});
var CommentForm = React.createClass({
    getInitialState: function(){
        return {author: '', text: ''};
    },
    handleAuthorChange: function(e){
        this.setState({author: e.target.value});
    },
    handleTextChange: function(e){
        this.setState({description: e.target.value});
    },
    handleSubmit: function(e){
        e.preventDefault();
        var author = this.state.author.trim();
        var description = this.state.description.trim();
        if(!description || !author){
            return;
        }
        this.props.onCommentSubmit({author: author, description: description});
        this.setState({author: '', text: ''});
    },
    render: function(){
        return (
          <form className="commentForm" onSubmit={this.handleSubmit}>
              <input type="text" placeholder="Your name" value={this.state.author} onChange={this.handleAuthorChange} />
              <input type="text" placeholder="Say something..." value={this.state.description} onChange={this.handleTextChange} />
              <input type="submit" value="Post" />
          </form>
      )
  }
});
var CommentList = React.createClass({
    render: function() {
        var commentNodes = this.props.data.map(function(comment){
            return (
              <Comment author={comment.Author} key={comment.Id}>{comment.Description}
              </Comment>
      );
});
return (
  <div className="commentList">{commentNodes}
  </div>
    );
}
});

var Comment = React.createClass({
    rawMarkup: function(){
        var md = new Remarkable();
        var rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup};
    },

    render: function(){
        return (
          <div className="comment">
            <h2 className="commentAuthor">{this.props.author}
            </h2>
            <span dangerouslySetInnerHTML={this.rawMarkup()} />
          </div>
      );
    }
});

var data = [
  {id: 1, author: "Phung", description: "day la Phung"},
  {id: 2, author: "Thuan", description: "day la Thuan"},
  {id: 3, author: "Anh", description: "day la Anh"},
  {id: 4, author: "Hung", description: "day la Hung"}
];

ReactDOM.render(
  <CommentBox url="http:///localhost:51787//api//comments" submitUrl='http://localhost:51787/api/addComment' pollInterval={2000} />,
  document.getElementById('content')
);