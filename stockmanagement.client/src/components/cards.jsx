const Card = ({ imgSrc, title }) => {
    return (
      <div className="card">
        <img src={imgSrc} alt={title} className="card-icon" />
        <div className="card-title">{title}</div>
      </div>
    );
  };


export default Card;


